//var testdata='[{"name":"box_hy","value":"未婚"},{"name":"box_zy","value":"无"},{"name":"box_mz","value":"汉族"},{"name":"box_whcd","value":"无"},{"name":"radio_ryfs","value":"0"},{"name":"date_rysj","value":"2015-06-16 15:48:28"},{"name":"date_sjzl","value":"2015-06-16 15:48:31"},{"name":"radio_ylfy","value":"0"},{"name":"text_ylfyqt","value":""},{"name":"text_ryzd","value":"感冒"},{"name":"text_jtzz","value":"英德"},{"name":"text_lxr","value":"张单"},{"name":"text_hzgx","value":"父女"},{"name":"text_phone","value":"18976452431"},{"name":"text_tiwen","value":"39"},{"name":"text_p","value":"120"},{"name":"text_r","value":"80"},{"name":"text_bp1","value":"10"},{"name":"text_bp2","value":"123"},{"name":"text_shengao","value":"170"},{"name":"text_tizhong","value":"50"},{"name":"radio_gms","value":"0"},{"name":"text_gmsyaowu","value":""},{"name":"text_gmsshiwu","value":""},{"name":"text_gmsqt","value":""},{"name":"radio_jws","value":"0"},{"name":"text_jwsqt","value":""},{"name":"radio_jzs","value":"0"},{"name":"text_jzsqt","value":""},{"name":"radio_ys","value":"0"},{"name":"radio_yy","value":"0"},{"name":"radio_pfys","value":"0"},{"name":"radio_pfsd","value":"0"},{"name":"radio_pfwzx","value":"0"},{"name":"radio_pftx","value":"0"},{"name":"radio_sz","value":"0"},{"name":"radio_yc","value":"0"},{"name":"text_ycbuwei","value":""},{"name":"text_ycmianji","value":""},{"name":"text_ycchengdu","value":""},{"name":"radio_kc","value":"0"},{"name":"radio_slzy","value":"0"},{"name":"text_slzy","value":""},{"name":"radio_slyy","value":"0"},{"name":"text_slyy","value":""},{"name":"radio_slze","value":"0"},{"name":"text_slze","value":""},{"name":"radio_slye","value":"0"},{"name":"text_slye","value":""},{"name":"radio_jbss","value":"0"},{"name":"radio_shiyu","value":"0"},{"name":"radio_shuimian","value":"0"},{"name":"radio_zthd","value":"0"},{"name":"text_zthdbw","value":""},{"name":"radio_zlnl","value":"0"},{"name":"radio_shihao","value":"0"},{"name":"text_shihaoqt","value":""},{"name":"radio_paibian","value":"0"},{"name":"radio_painiao","value":"0"},{"name":"radio_dgqk","value":"0"},{"name":"text_dgqkqt","value":""},{"name":"radio_wxys","value":"0"},{"name":"radio_hjaq","value":"0"},{"name":"text_hjaqqt","value":""},{"name":"radio_qxzt","value":"0"},{"name":"text_qxztqt","value":""},{"name":"radio_zyzt","value":"0"},{"name":"radio_jszt","value":"0"},{"name":"text_beizhu","value":"大多多"},{"name":"text_hsqm","value":"里水电费"},{"name":"text_shijian","value":""}]';


//加载文书数据，页面打开时显示数据
function ws_loaddata(){
    var data=$.evalJSON($("#rypgd_info").val());
    if(data){ 
		var formdata={};
		$.each( data, function(i, n){
		  var item='{"'+n.name+'":"'+n.value+'"}';
		  var itemjson=$.evalJSON(item);
		  jQuery.extend(formdata, itemjson);
		});
		
        $('#ws_form').form('load',formdata);
    }
}
//写入文书数据，存入到数据库中
function ws_writedata(){
	var data = $("#ws_form").serializeArray(); //自动将form表单封装成json
    $("#rypgd_info").val($.toJSON(data));
}

var easyui;
$(function(){	
    ws_loaddata();
	easyui=$('.wenshu_baseinfo .textbox');
	editState(false);
});

function editState(flag){
	if(flag){
		easyui.addClass('textbox').addClass('combo');
		easyui.find('span').show();
		//$('input').removeAttr("readonly");
		$('input').removeAttr("disabled");
	}else{
		easyui.removeClass('textbox').removeClass('combo').removeClass('datebox');
		easyui.find('span').hide();
		//$('input').attr("readonly","readonly");
		$('input').attr("disabled","disabled");
	}
}


//完成
function finishdata(){
	var isValid = $('#ws_form').form('validate');
	if(isValid){
		ws_writedata();
		editState(false);
	}
}
//修改
function alterdata(){
	editState(true);
}

//清空
function cleardata(){
    $('#ws_form').form('clear');
	ws_writedata();
	editState(true);
}

var box_hydata=[{"name":"未婚"},{"name":"已婚"},{"name":"离异"}];
var box_zydata=[{"name":"无"},{"name":"学生"},{"name":"工人"},{"name":"农民"},{"name":"个体"},{"name":"干部"},{"name":"退休"}];
var box_mzdata=[{"name":"汉族"},{"name":"蒙古族"},{"name":"回族"},{"name":"藏族"},{"name":"维吾尔族"},{"name":"苗族"},{"name":"彝族"},{"name":"壮族"},{"name":"布依族"},{"name":"朝鲜族"},{"name":"满族"},{"name":"侗族"},{"name":"瑶族"},{"name":"白族"},{"name":"土家族"},{"name":"哈尼族"},{"name":"哈萨克族"},{"name":"傣族"},{"name":"黎族"},{"name":"傈僳族"},{"name":"佤族"},{"name":"畲族"},{"name":"高山族"},{"name":"拉祜族"},{"name":"水族"},{"name":"东乡族"},{"name":"纳西族"},{"name":"景颇族"},{"name":"柯尔克孜族"},{"name":"土族"},{"name":"达斡尔族"},{"name":"仫佬族"},{"name":"羌族"},{"name":"布朗族"},{"name":"撒拉族"},{"name":"毛难族"},{"name":"仡佬族"},{"name":"锡伯族"},{"name":"阿昌族"},{"name":"普米族"},{"name":"塔吉克族"},{"name":"怒族"},{"name":"乌孜别克族"},{"name":"俄罗斯族"},{"name":"鄂温克族"},{"name":"崩龙族"},{"name":"保安族"},{"name":"裕固族"},{"name":"京族"},{"name":"塔塔尔族"},{"name":"独龙族"},{"name":"鄂伦春族"},{"name":"赫哲族"},{"name":"门巴族"},{"name":"珞巴族"},{"name":"基诺族"}];
var box_whcddata=[{"name":"无"},{"name":"小学"},{"name":"初中"},{"name":"高中"},{"name":"中专"},{"name":"大学"}];
