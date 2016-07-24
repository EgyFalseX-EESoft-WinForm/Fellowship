using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Fellowship
{
    public partial class tblmembersp_schoolsWFrm : DevExpress.XtraEditors.XtraForm
    {

        DataSources.DSFellowship.tblmembersp_schoolsRow _row;

        public tblmembersp_schoolsWFrm()
        {
            InitializeComponent();
        }
        public tblmembersp_schoolsWFrm(DataSources.DSFellowship.tblmembersp_schoolsRow row)
        {
            InitializeComponent();
            _row = row;
        }
        private void LoadData()
        {
            this.schoolTableAdapter.Fill(this.dSFellowship.school);
        }
        private void LoadBinding()
        {
            if (!_row.IsNull("MNAME"))
                tbMNAME.EditValue = _row.MNAME;
            if (!_row.IsNull("schoolcode"))
                lueschoolcode.EditValue = _row.schoolcode;
            if (!_row.IsNull("membernid"))
                tbmembernid.EditValue = _row.membernid;
            if (!_row.IsNull("mobil"))
                tbMobile.EditValue = _row.mobil;
            if (!_row.IsNull("address"))
                tbaddress.EditValue = _row.address;
        }
        private void TBLSheekWaredWFrm_Load(object sender, EventArgs e)
        {
            LoadData();
            LoadBinding();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!dxvp.Validate())
                return;

            if (tbMNAME.EditValue != null)
                _row.MNAME = Convert.ToString(tbMNAME.EditValue);
            if (lueschoolcode.EditValue != null)
                _row.schoolcode = Convert.ToInt32(lueschoolcode.EditValue);

            if (tbmembernid.EditValue != null)
                _row.membernid = Convert.ToString(tbmembernid.EditValue);
            if (tbMobile.EditValue != null)
                _row.mobil = Convert.ToString(tbMobile.EditValue);
            if (tbaddress.EditValue != null)
                _row.address = Convert.ToString(tbaddress.EditValue);

            _row.userin = Convert.ToInt32(FXFW.SqlDB.UserInfo.UserID);
            _row.datein = DateTime.Now;

            DialogResult = System.Windows.Forms.DialogResult.OK;

        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

    }
}