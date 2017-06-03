using System;

namespace EfwControls.HISControl.Prescription.Controls.Entity
{
    public class OPD_PresMouldHead
    {
        private int _presmouldheadid;
        public int PresMouldHeadID
        {
            get { return _presmouldheadid; }
            set { _presmouldheadid = value; }
        }

        private int _pid;
        public int PID
        {
            get { return _pid; }
            set { _pid = value; }
        }

        private string _moduldname;
        public string ModuldName
        {
            get { return _moduldname; }
            set { _moduldname = value; }
        }

        private int _mouldtype;
        public int MouldType
        {
            get { return _mouldtype; }
            set { _mouldtype = value; }
        }

        private int _prestype;
        public int PresType
        {
            get { return _prestype; }
            set { _prestype = value; }
        }

        private int _modullevel;
        public int ModulLevel
        {
            get { return _modullevel; }
            set { _modullevel = value; }
        }

        private int _createempid;
        public int CreateEmpID
        {
            get { return _createempid; }
            set { _createempid = value; }
        }

        private int _createdeptid;
        public int CreateDeptID
        {
            get { return _createdeptid; }
            set { _createdeptid = value; }
        }

        private DateTime _createdate;
        public DateTime CreateDate
        {
            get { return _createdate; }
            set { _createdate = value; }
        }

        private int _delflag;
        public int DelFlag
        {
            get { return _delflag; }
            set { _delflag = value; }
        }
    }
}