using System;
using System.Collections.Generic;
using BaseX;
using FrooxEngine;
using FrooxEngine.LogiX;
using FrooxEngine.UIX;

namespace LeftoverLogixComponentRemover
{
    [Category("Wizards")]
    public class LeftoverLogixComponentRemoverWizard : Component
    {
        public readonly SyncRef<Slot> ProcessRoot;
        public readonly SyncRef<Text> ResultsText;
        private LocaleString _text;
        private int _count;

        protected override void OnAttach()
        {
            base.OnAttach();
            base.Slot.Tag = "Developer";
            this.Slot.Name = "Leftover LogiX Component Remover";
            NeosCanvasPanel neosCanvasPanel = base.Slot.AttachComponent<NeosCanvasPanel>();
            neosCanvasPanel.Panel.AddCloseButton();
            neosCanvasPanel.Panel.AddParentButton();
            neosCanvasPanel.Panel.Title = "Leftover LogiX Component Remover";
            neosCanvasPanel.CanvasSize = new float2(300f, 200f);
            UIBuilder uIBuilder = new UIBuilder(neosCanvasPanel.Canvas);
            uIBuilder.VerticalLayout(4f);
            uIBuilder.FitContent(SizeFit.Disabled, SizeFit.MinSize);
            uIBuilder.Style.Height = 24f;
            _text = "Process root slot:";
            uIBuilder.Text(in _text);
            uIBuilder.Next("Root");
            uIBuilder.Current.AttachComponent<RefEditor>().Setup(ProcessRoot);
            uIBuilder.Spacer(24f);
            _text = "Remove LogixInterfaceProxy components";
            uIBuilder.Button(in _text, RemoveLogixInterfaceProxies);
            _text = "Remove LogixReference components";
            uIBuilder.Button(in _text, RemoveLogixReferences);
            uIBuilder.Spacer(24f);
            _text = "------";
            ResultsText.Target = uIBuilder.Text(in _text);
        }

        protected override void OnStart()
        {
            base.OnStart();
            base.Slot.GetComponentInChildrenOrParents<Canvas>()?.MarkDeveloper();
        }

        private void ShowResults(string results)
        {
            ResultsText.Target.Content.Value = results;
        }

        private void RemoveLogixInterfaceProxies(IButton button, ButtonEventData eventData)
        {
            _count = 0;
            if (ProcessRoot.Target != null)
            {
                foreach (LogixInterfaceProxy componentsInChildren in ProcessRoot.Target.GetComponentsInChildren<LogixInterfaceProxy>())
                {
                    componentsInChildren.Destroy();
                    _count++;
                }
                ShowResults($"{_count} LogixInterfaceProxy components removed.");
            }
            else ShowResults("No ProcessRoot Slot set.");
        }

        private void RemoveLogixReferences(IButton button, ButtonEventData eventData)
        {
            _count = 0;
            if (ProcessRoot.Target != null)
            {
                foreach (LogixReference componentsInChildren in ProcessRoot.Target.GetComponentsInChildren<LogixReference>())
                {
                    componentsInChildren.Destroy();
                    _count++;
                }
                ShowResults($"{_count} LogixReference components removed.");
            }
            else ShowResults("No ProcessRoot Slot set.");
        }
    }
}
