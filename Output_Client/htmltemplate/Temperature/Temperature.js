//数据结构
//var tp_jsondata='{"title":{"date":["2015-5-1","2015-5-2","2015-5-3","2015-5-4","2015-5-5","2015-5-6","2015-5-7"],"day":["1","2","3","4","5","6","7"],"operday":["","","","0","1","2","3"]},"lines":[{"datatype":3,"date":[{"index":1,"text":"2015-5-1","time":["38.5","40","41","D","38","39"]},{"index":2,"text":"2015-5-2","time":["38.5","40","41","D","38","39"]}]},{"datatype":4,"date":[{"index":1,"text":"2015-5-1","time":["100","105","120","99","80","100"]},{"index":2,"text":"2015-5-2","time":["80","90","100","110","120","130"]}]}],"other":{}}';
//var tp_data=$.evalJSON(tp_jsondata);
/*点样式
1 口温
2 腋温
3 肛温
4 脉搏
5 心率
6 呼吸
7 降温*/
var pointtype=[
{name:'',size: 4, face: 'o',fillColor:'#ff0000',strokeColor:'#ff0000'},
{name:'',size: 4, face: 'x',fillColor:'#ff0000',strokeColor:'#ff0000'},
{name:'',size: 4, face: 'o',fillColor:'#ffffff',strokeColor:'#ff0000'},
{name:'',size: 4, face: 'o',fillColor:'#0000ff',strokeColor:'#0000ff'},
{name:'',size: 4, face: 'x',fillColor:'#0000ff',strokeColor:'#0000ff'},
{name:'',size: 4, face: 'o',fillColor:'#ffffff',strokeColor:'#0000ff'},
{name:'',size: 4, face: '<>'}
];
//线样式
var linetype=[
{straightFirst:false, straightLast:false,strokeColor:'#ff0000',strokeWidth:2},
{straightFirst:false, straightLast:false,strokeColor:'#ff0000',strokeWidth:2},
{straightFirst:false, straightLast:false,strokeColor:'#ff0000',strokeWidth:2},
{straightFirst:false, straightLast:false,strokeColor:'#0000ff',strokeWidth:2},
{straightFirst:false, straightLast:false,strokeColor:'#0000ff',strokeWidth:2},
{straightFirst:false, straightLast:false,strokeColor:'#0000ff',strokeWidth:2},
{straightFirst:false, straightLast:false,strokeColor:'#ff0000',strokeWidth:2}
];

//创建画板
function LoadBoard(data,board){
            //var arrpoint=[];//存储点
            var beginpoint,endpoint;//开始点和结束点
            var arrline=[];//存储线的开始结束点  [{begin:p1,end:p2},{begin:p2,end:p3}]
            var _pointtype=pointtype[parseInt(data.datatype)-1];
            var _linetype=linetype[parseInt(data.datatype)-1];
                
            $.each(data.date,function(i,n){
                var dateindex=n.index;
                $.each(n.time,function(k,v){
                
                    if(v!="N" && v!="O" && v!="D"){
                       /**********begin***********/
                        var arr_index=k;
                        var _location;
                        //点
                        if(data.datatype==1 || data.datatype==2 ||data.datatype==3 ||data.datatype==7){//体温
                             _location=getlocation_temperature(dateindex,arr_index,v);
                        }
                        else if(data.datatype==4){//脉搏
                             _location=getlocation_pulse(dateindex,arr_index,v);
                        }
                        else if(data.datatype==5){//心率
                             _location=getlocation_pulse(dateindex,arr_index,v);
                        }
                        else if(data.datatype==6){//呼吸
                             _location=getlocation_breathe(dateindex,arr_index,v);
                        }
                        
                         var _point=board.createElement('point',[_location.x,_location.y], _pointtype);//画点
                            //arrpoint.push(_point);
                            if(!beginpoint){
                                beginpoint=_point;
                            }else if(beginpoint && !endpoint){
                                endpoint=_point;
                                arrline.push({begin:beginpoint,end:endpoint});//存储线相连的点
                                beginpoint=_point;
                                endpoint=null;
                            }
                    /**********end***********/        
                    }else if(v=="O" || v=="D"){//拒测和外出不连线
                            beginpoint=null;
                            endpoint=null;
                        }
                });
            });
            
            //画线
            $.each(arrline,function(i,n){
                board.createElement('line',[n.begin,n.end],_linetype);//画线
            });
            
            //画时间文本
            
           return board;
}

//加载文书数据，页面打开时显示数据
function ws_loaddata(){
    var tp_data=$.evalJSON($("#scd_data").val());//从input获取
    if(tp_data){
            //日期
           $.each(tp_data.title.date,function(i,n){
            var target= $('.temperature_date table tr:first td:not(:first)').get(i);
                $(target).text(n);
            });
            $.each(tp_data.title.day,function(i,n){
            var target= $('.temperature_date table tr:eq(1) td:not(:first)').get(i);
                $(target).text(n);
            });
            $.each(tp_data.title.operday,function(i,n){
            var target= $('.temperature_date table tr:eq(2) td:not(:first)').get(i);
                $(target).text(n);
            });
            //定义画板,顺时针左上右下，由于时段要填在空白上，所以向左偏移-0.5
            var board = JXG.JSXGraph.initBoard('drawlineDiv', {boundingbox: [-0.5, 40, 41.5, 0],showCopyright:false});
            //画线
            $.each(tp_data.lines,function(i,n){
                LoadBoard(n,board);
            });
            //画时间文本
             $.each(tp_data.drawtext.timetext,function(i,n){
                var text=n.type+"—"+convertTime(n.value);
                alert(text);
                board.create('text', [getdrawtimetext_X(tp_data.title.date,n.value)-0.2, 40, text], {display:'internal', rotate:270,color:'#ff0000'});
            });
            //
            //$.each(tp_data.mscounttext.amount,function(i,n){
                //var text=n.type+"—"+convertTime(n.value);
                //board.create('text', [getdrawtimetext_X(tp_data.title.date,n.value)-0.2, 40, text], {display:'internal', rotate:270,color:'#ff0000'});
            //});
            //其他
            
    }
}
//写入文书数据，存入到数据库中
function ws_writedata(){
}


$(function(){
	ws_loaddata();
	
});

//arrdate=tp_data.title.date  time=tp_data.drawtext.timetext.value
function getdrawtimetext_X(arrdate,time){
    var dayindex=-1;
    var text_x;
    var date=new Date(Date.parse(time.replace(/-/g,"/")));
    $.each(arrdate,function(i,n){
        var d=new Date(Date.parse(n.replace(/-/g,"/")));
        if(date.getFullYear()==d.getFullYear() && date.getMonth()==d.getMonth() && date.getDay()==d.getDay()){
            dayindex=i;
        }
    });
    if(dayindex>-1){
        var timeindex= (date.getHours()-date.getHours()%6)/6;
        return timeindex+dayindex*6;
    }
    return 0;
}
/*
//第几天，几点，温度值
function getlocation_temperature(dateindex,arr_index,val){
    var location={x:0,y:0};
    location.x=arr_index+(dateindex-1)*6;
    location.y=(parseFloat(val)-34)*5;//对照图片
    return location;
}
//脉搏
function getlocation_pulse(dateindex,arr_index,val){
    var location={x:0,y:0};
    location.x=arr_index+(dateindex-1)*6;
    location.y=(parseFloat(val)-20)/4;//对照图片
    return location;
}
//呼吸
function getlocation_breathe(dateindex,arr_index,val){
    var location={x:0,y:0};
    location.x=arr_index+(dateindex-1)*6;
    location.y=(parseFloat(val)-10)/2;//对照图片
    return location;
}
*/
function getlocation_temperature(dateindex,arr_index,val){var location={x:0,y:0};location.x=arr_index+(dateindex-1)*6;location.y=(parseFloat(val)-34)*5;return location}function getlocation_pulse(dateindex,arr_index,val){var location={x:0,y:0};location.x=arr_index+(dateindex-1)*6;location.y=(parseFloat(val)-20)/4;return location}function getlocation_breathe(dateindex,arr_index,val){var location={x:0,y:0};location.x=arr_index+(dateindex-1)*6;location.y=(parseFloat(val)-10)/2;return location}
function convertTime(val){var date=new Date(Date.parse(val.replace(/-/g,"/")));var hours=date.getHours();var minute=date.getMinutes();return intToChinese(hours)+"时"+intToChinese(minute)+"分"}
/*****javascript中将数字转换为中文*****/
function intToChinese(str){str=str+'';var len=str.length-1;var idxs=['','十','百','千','万','十','百','千','亿','十','百','千','万','十','百','千','亿'];var num=['零','一','二','三','四','五','六','七','八','九'];return str.replace(/([1-9]|0+)/g,function($,$1,idx,full){var pos=0;if($1[0]!='0'){pos=len-idx;if(idx==0&&$1[0]==1&&idxs[len-idx]=='十'){return idxs[len-idx]}return num[$1[0]]+idxs[len-idx]}else{var left=len-idx;var right=len-idx+$1.length;if(Math.floor(right/4)-Math.floor(left/4)>0){pos=left-left%4}if(pos){return idxs[pos]+num[$1[0]]}else if(idx+$1.length>=len){return''}else{return num[$1[0]]}}})}