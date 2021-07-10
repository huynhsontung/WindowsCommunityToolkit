using System.Collections.Generic;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Markup;
using Microsoft.Toolkit.Uwp;
using Microsoft.Toolkit.Uwp.UI;
using Microsoft.Toolkit.Uwp.UI.Controls;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UnitTesting.AppContainer;

namespace UnitTests.UWP.UI.Controls
{
    [TestClass]
    [TestCategory(nameof(Test_RichSuggestBox))]
    public class Test_RichSuggestBox : VisualUITestBase
    {
        [TestMethod]
        public async Task Test_RichSuggestBox_AddToken()
        {
            await App.DispatcherQueue.EnqueueAsync(() =>
            {
                var rsb = new RichSuggestBox { Prefixes = "@" };

                Assert.IsNotNull(rsb, "Could not find RichSuggestBox in tree.");

                //rsb.TextDocument.Selection.TypeText("@");

                //await Task.Delay(200);

                //Assert.IsTrue(suggestionRequested, "SuggestionRequested event did not trigger.");
                //Assert.AreEqual(suggestionsList.Items.Count, 1, "Suggestions items are not populated.");
            });
        }
    }
}
