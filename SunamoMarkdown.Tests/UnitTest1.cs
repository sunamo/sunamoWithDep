namespace SunamoMarkdown.Tests
{
    public class MarkdownHelperTests
    {
        [Fact]
        public void ConvertToMarkDownTest()
        {
            // Convert good
            var html = "Something to <strong>convert</strong>";
            string md = MarkdownHelper.ConvertToMarkDown(html);
            int i = 0;

            // Html2Markdown return always same as input string
            html = "<!--StartFragment--><span style=\"color: rgb(0, 0, 128); font - family: Arial, Helvetica, sans - serif; font - size: 16px; font - style: normal; font - variant - ligatures: normal; font - variant - caps: normal; font - weight: 400; letter - spacing: normal; orphans: 2; text - align: start; text - indent: 0px; text - transform: none; white - space: normal; widows: 2; word - spacing: 0px; -webkit - text - stroke - width: 0px; background - color: rgb(255, 255, 255); text - decoration - style: initial; text - decoration - color: initial; display: inline !important; float: none; \">They<span>�</span></span><strong style=\"color: rgb(0, 0, 128); font - family: Arial, Helvetica, sans - serif; font - size: 16px; font - style: normal; font - variant - ligatures: normal; font - variant - caps: normal; letter - spacing: normal; orphans: 2; text - align: start; text - indent: 0px; text - transform: none; white - space: normal; widows: 2; word - spacing: 0px; -webkit - text - stroke - width: 0px; background - color: rgb(255, 255, 255); text - decoration - style: initial; text - decoration - color: initial; \">will have completed</strong><span style=\"color: rgb(0, 0, 128); font - family: Arial, Helvetica, sans - serif; font - size: 16px; font - style: normal; font - variant - ligatures: normal; font - variant - caps: normal; font - weight: 400; letter - spacing: normal; orphans: 2; text - align: start; text - indent: 0px; text - transform: none; white - space: normal; widows: 2; word - spacing: 0px; -webkit - text - stroke - width: 0px; background - color: rgb(255, 255, 255); text - decoration - style: initial; text - decoration - color: initial; display: inline !important; float: none; \"><span>�</span>the project before the deadline.</span><!--EndFragment-->";

        }
    }
}
