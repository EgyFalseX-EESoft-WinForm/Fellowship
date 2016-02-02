using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;
using DevExpress.XtraReports.Parameters;
using DevExpress.XtraEditors;

namespace Fellowship
{
    public partial class XRep02 : DevExpress.XtraReports.UI.XtraReport
    {
        DataSources.DSFellowshipReportTableAdapters.XRep02_ATableAdapter adpA = new DataSources.DSFellowshipReportTableAdapters.XRep02_ATableAdapter();
        DataSources.DSFellowshipReportTableAdapters.XRep02_BTableAdapter adpB = new DataSources.DSFellowshipReportTableAdapters.XRep02_BTableAdapter();
        DataSources.DSFellowshipReportTableAdapters.XRep02TableAdapter adp = new DataSources.DSFellowshipReportTableAdapters.XRep02TableAdapter();
        public XRep02()
        {
            InitializeComponent();
            LoadDataSource();
        }
        private void LoadDataSource()
        {
            //adpA.Fill(dsFellowshipReport.XRep02_A);
            adpB.Fill(dsFellowshipReport.XRep02_B);
        }
        private void XRep02_ParametersRequestSubmit(object sender, DevExpress.XtraReports.Parameters.ParametersRequestEventArgs e)
        {
            if (Parameters["paramedaraid"].Value == DBNull.Value && Parameters["paramgovid"].Value == DBNull.Value)
            {
                return;
            }
            int edaraid = Convert.ToInt32(Parameters["paramedaraid"].Value);
            byte govid = Convert.ToByte(Parameters["paramgovid"].Value);
            adp.Fill(dsFellowshipReport.XRep02, govid, edaraid);

            foreach (ParameterInfo pram in e.ParametersInformation)
            {
                if (pram.Parameter.Name == "paramedaraid")
                {
                    xledaraid.Text = ((LookUpEdit)pram.Editor).Text;
                    continue;
                }
                if (pram.Parameter.Name == "paramgovid")
                {
                    xlgovid.Text = ((LookUpEdit)pram.Editor).Text;
                    continue;
                }
            }
        }
        private void XRep02_ParametersRequestValueChanged(object sender, ParametersRequestValueChangedEventArgs e)
        {
            if (e.ChangedParameterInfo.Parameter.Name == "paramgovid")
            {
                byte id = Convert.ToByte(((LookUpEdit)e.ChangedParameterInfo.Editor).EditValue);
                ((LookUpEdit)e.ParametersInformation[1].Editor).Properties.DataSource = adpA.GetDataGovId(id);
                ((LookUpEdit)e.ParametersInformation[1].Editor).Properties.DisplayMember = "EDARET";
                ((LookUpEdit)e.ParametersInformation[1].Editor).Properties.ValueMember = "EdaraId";
                //adpB.FillByID(dsFellowshipReport.XRep02_B, id);
            }
        }
    }
}
