using System;
using System.Runtime.InteropServices;
using System.IO;

using Microsoft.SharePoint;
using Microsoft.SharePoint.Workflow;
using System.Globalization;
using Microsoft.SharePoint.Utilities;

namespace SiteDefinition1
{
    public partial class SiteDefinition1
    {
        /// <summary>
        ///  Define your own feature activation action code here
        /// </summary>
        public void OnActivated(SPFeatureReceiverProperties properties)
        {
            SPWeb web;
            if (properties.Feature.Parent is SPWeb)
                web = (SPWeb)properties.Feature.Parent;
            else
                web = ((SPSite)properties.Feature.Parent).RootWeb;

            SetMasterPage(web);
            SetProposalsWorkflow(web);
        }

        private void SetMasterPage(SPWeb web)
        {
            web.AllowUnsafeUpdates = true;

            // 発行インフラストラクチャーフィーチャーの Activate
            web.Site.Features.Add(new Guid("f6924d36-2fa8-4f0b-b16d-06b7250180fa"), true);

            // インストールしたカスタムマスターページの Activate
            web.Site.Features.Add(new Guid("bec7f3a3-e53e-4c6e-b3d6-83604b8092bb"), true);

            // このサイトにカスタムマスターページを設定
            web.MasterUrl = SPUrlUtility.CombineUrl(web.Site.ServerRelativeUrl, "_catalogs/masterpage/MyDemoMaster.master");
            //web.MasterUrl = web.Site.ServerRelativeUrl + "/_catalogs/masterpage/MyDemoMaster.master";
            web.Update();
        }

        private void SetProposalsWorkflow(SPWeb web)
        {
            web.AllowUnsafeUpdates = true;
            SPList targetList = web.Lists["Proposals"];

            // ワークフローフィーチャーの Activate
            web.Site.Features.Add(new Guid("F8222634-F70A-401c-A39F-5911FB2B3E78"), true);

            // ワークフローテンプレートの取得
            SPWorkflowTemplate wfTmpl = web.WorkflowTemplates.GetTemplateByBaseID(new Guid("5AF9335C-9D4F-4aa1-93C9-C079F469D9D2"));

            // タスクリストの取得
            SPList taskList = web.Lists["Tasks"];

            // ワークフロー履歴リストの取得 (その前に作成)
            string histListName = "ワークフローの履歴";
            SPListTemplateType prcListTemplateTypeHistory = SPListTemplateType.WorkflowHistory;
            web.Lists.Add(histListName, "history list", prcListTemplateTypeHistory);
            SPList histList = web.Lists[histListName];

            // ワークフローの関連設定
            SPWorkflowAssociation wfAssoc = SPWorkflowAssociation.CreateListAssociation(wfTmpl, "AutoWorkflow", taskList, histList);

            wfAssoc.AllowAsyncManualStart = false;
            wfAssoc.AllowManual = true;
            wfAssoc.AutoStartCreate = true;
            wfAssoc.AutoStartChange = false;

            targetList.AddWorkflowAssociation(wfAssoc);
        }

    }
}
