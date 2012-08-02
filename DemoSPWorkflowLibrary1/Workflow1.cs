using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Collections;
using System.Drawing;
using System.Workflow.ComponentModel.Compiler;
using System.Workflow.ComponentModel.Serialization;
using System.Workflow.ComponentModel;
using System.Workflow.ComponentModel.Design;
using System.Workflow.Runtime;
using System.Workflow.Activities;
using System.Workflow.Activities.Rules;
using System.Xml.Serialization;
using System.Xml;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Workflow;
using Microsoft.SharePoint.WorkflowActions;
using Microsoft.Office.Workflow.Utility;

namespace DemoSPWorkflowLibrary1
{
	public sealed partial class Workflow1: SharePointSequentialWorkflowActivity
	{
		public Workflow1()
		{
			InitializeComponent();
		}

        public Guid workflowId = default(System.Guid);
        public Microsoft.SharePoint.Workflow.SPWorkflowActivationProperties workflowProperties = new Microsoft.SharePoint.Workflow.SPWorkflowActivationProperties();
        public Guid taskId = default(System.Guid);
        public SPWorkflowTaskProperties afterProps = new Microsoft.SharePoint.Workflow.SPWorkflowTaskProperties();
        public SPWorkflowTaskProperties beforeProps = new Microsoft.SharePoint.Workflow.SPWorkflowTaskProperties();
        public String historyDesc = default(System.String);

        public string assignee = default(string);
        public string instructions = default(string);
        private bool isFinished = false;

        private void onWorkflowActivated(object sender, ExternalDataEventArgs e)
        {
            // desiriarize xml to the instance
            workflowId = workflowProperties.WorkflowId;

            // set value
            assignee = System.Threading.Thread.CurrentPrincipal.Identity.Name;
            instructions = "";
        }

        private void createTask(object sender, EventArgs e)
        {
            taskId = Guid.NewGuid();
            taskProps.TaskType = 0;
            taskProps.AssignedTo = assignee;
            taskProps.Title = "Please review this";
            taskProps.Description = instructions;
            taskProps.ExtendedProperties["instructions"] = instructions;
        }

        private void onTaskChanged(object sender, ExternalDataEventArgs e)
        {
            isFinished = bool.Parse(afterProps.ExtendedProperties["isFinished"].ToString());
        }

        private void notFinished(object sender, ConditionalEventArgs e)
        {
            e.Result = !isFinished;
        }

        private void completeTask(object sender, EventArgs e)
        {
            historyDesc = "Workflow completed by " + assignee;
        }

        public SPWorkflowTaskProperties taskProps = new Microsoft.SharePoint.Workflow.SPWorkflowTaskProperties();
	}

}
