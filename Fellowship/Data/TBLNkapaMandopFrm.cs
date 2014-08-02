﻿
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Data.SqlClient;
using FXFW;
using DevExpress.XtraGrid.Views.Grid;

namespace Fellowship
{
    public partial class TBLNkapaMandopFrm : DevExpress.XtraEditors.XtraForm
    {
        #region -   Functions   -
        public TBLNkapaMandopFrm()
        {
            InitializeComponent();
        }
        private void LoadDefaultData(Types.TablesNames TableName)
        {
            switch (TableName)
            {
                case Types.TablesNames.CDSyndicate:
                    cDSyndicateTableAdapter.Fill(dSFellowship.CDSyndicate);
                    break;
                case Types.TablesNames.All:
                    //CDSyndicate
                    cDSyndicateTableAdapter.Fill(dSFellowship.CDSyndicate);
                    break;
                default:
                    break;
            }
        }
        private void LoadGrid()
        {
            tBLNkapaMandopTableAdapter.Fill(dSFellowship.TBLNkapaMandop);
        }
        private void ActiveKeyDownEvent(object sender, KeyEventArgs e)
        {
            if (e.KeyData != Keys.F5 && e.KeyData != Keys.F6 && e.KeyData != Keys.F10 && e.KeyData != Keys.F8)
                return;
            switch (e.KeyData)
            {
                case Keys.F1:
                    break;
                case Keys.F5:
                    tBLNkapaMandopBindingSource.AddNew();
                    break;
                case Keys.F6:
                    repositoryItemButtonEditSave_ButtonClick(repositoryItemButtonEditSave, new DevExpress.XtraEditors.Controls.ButtonPressedEventArgs(new DevExpress.XtraEditors.Controls.EditorButton()));
                    break;
                case Keys.F8:
                    repositoryItemButtonEditDel_ButtonClick(repositoryItemButtonEditDel, new DevExpress.XtraEditors.Controls.ButtonPressedEventArgs(new DevExpress.XtraEditors.Controls.EditorButton()));
                    break;
                case Keys.F10:
                    repositoryItemButtonEditSave_ButtonClick(repositoryItemButtonEditSave, new DevExpress.XtraEditors.Controls.ButtonPressedEventArgs(new DevExpress.XtraEditors.Controls.EditorButton()));
                    break;
                default:
                    break;
            }
        }
        private void ActivePriv()
        {
            return;
            bool Selecting = false, Inserting = false, Updateing = false, Deleting = false;
            SqlDB.GetFormPriv("Fellowship" + Name.Replace("Frm", ""), ref Selecting, ref Inserting, ref  Updateing, ref  Deleting);
            gridControlData.Visible = Selecting;
            if (Inserting || Updateing)
                repositoryItemButtonEditSave.Buttons[0].Enabled = true;
            else
                repositoryItemButtonEditSave.Buttons[0].Enabled = false;
            repositoryItemButtonEditDel.Buttons[0].Enabled = Deleting;
        }
#endregion
        #region - Event Handlers -
        private void stu_nashatFrm_Load(object sender, EventArgs e)
        {
            ActivePriv();
            LoadDefaultData(Types.TablesNames.All);
            LoadGrid();
        }
        private void repositoryItemGridLookUpEditnkapaId_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Plus)
            {
                CodeFrm Code = new CodeFrm(Types.TablesNames.CDSyndicate);
                Code.ShowDialog();
                LoadDefaultData(Types.TablesNames.CDSyndicate);
            }
        }
        private void gridViewData_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            DataRowView DRV = (DataRowView)e.Row;
            if (e.ErrorText.Contains("nkapaMandopId"))
            {
                //e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction;
                DRV["nkapaMandopId"] = "-1";
                return;
            }
        }
        private void repositoryItemButtonEditSave_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            GridView GV = (GridView)gridControlData.MainView;
            Fellowship.DataSources.DSFellowship.TBLNkapaMandopRow row = (Fellowship.DataSources.DSFellowship.TBLNkapaMandopRow)GV.GetFocusedDataRow();
            
            try
            {
                if (row.RowState == DataRowState.Detached)
                {
                    row.nkapaMandopId = Convert.ToInt32(SqlDB.GetNewID("TBLNkapaMandop", "nkapaMandopId"));
                }
                tBLNkapaMandopBindingSource.EndEdit();
                tBLNkapaMandopTableAdapter.Update(row);
                dSFellowship.TBLNkapaMandop.AcceptChanges();

                Program.ShowMsg("تم الحفظ", false, this);
                Program.Logger.LogThis("تم الحفظ", Text, FXFW.Logger.OpType.success, null, null, this);
                LoadGrid();
            }
            catch (Exception ex)
            {
                Program.ShowMsg(Misc.Misc.ExceptionMessage(ex), true, this);
                Program.Logger.LogThis(null, Text, FXFW.Logger.OpType.fail, ex, null, this);
            }
        }
        private void repositoryItemButtonEditDel_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            GridView GV = (GridView)gridControlData.MainView;
            Fellowship.DataSources.DSFellowship.TBLNkapaMandopRow row = (Fellowship.DataSources.DSFellowship.TBLNkapaMandopRow)GV.GetFocusedDataRow();

            if (row.RowState == DataRowState.Detached)
                return;

            if (MessageBox.Show("هل انت متأكد؟", "تحزير ...", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == System.Windows.Forms.DialogResult.No)
                return;
            try
            {
                tBLNkapaMandopTableAdapter.Delete(row.nkapaMandopId);
                gridViewData.DeleteRow(GV.FocusedRowHandle);
                
                Program.ShowMsg("تم الحذف", false, this);
                Program.Logger.LogThis("تم الحذف", Text, FXFW.Logger.OpType.success, null, null, this);
            }
            catch (Exception ex)
            {
                Program.ShowMsg(Misc.Misc.ExceptionMessage(ex), true, this);
                Program.Logger.LogThis(null, Text, FXFW.Logger.OpType.fail, ex, null, this);
            }
        }
        #endregion
    }
}