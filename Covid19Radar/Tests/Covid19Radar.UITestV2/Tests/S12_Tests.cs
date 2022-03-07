﻿using System;
using System.IO;
using System.Linq;
using System.Threading;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace CovidRadar.UITestV2
{
    [TestFixture(Platform.Android)]
    [TestFixture(Platform.iOS)]
    public class S12_Tests : BaseTestFixture
    {
        public S12_Tests(Platform platform)
            : base(platform)
        {
        }

        /* Case1はライセンスページ遷移後の実装が出来なかったため手動実行
        [Test]
        public void Case01_Test()
        {
            HomePage home = new HomePage();
            home.AssertHomePage();

            MenuPage menuPage = home.OpenMenuPage();
            menuPage.AssertMenuPage();

            //S1 ハンバーガーメニューで、「使い方」ボタンを押下
            HelpMenuPage helpMenuPage = menuPage.OpenHelpMenuPage();
            helpMenuPage.AssertHelpMenuPage();

            //S2 「使い方」画面で、「接触の記録を停止 / 情報を削除するには」ボタンを押下
            HelpPage4 helpPage4 = helpMenuPage.OpenHelpPage4();
            helpPage4.AssertHelpPage4();

            //S3 「記録の停止 / 削除」画面で、「アプリの設定へ」ボタンを押下
            SettingsPage settingsPage = helpPage4.OpenSettingsPage();
            settingsPage.AssertSettingsPage();

            //S4 「設定」画面で、「ライセンス表記」ボタンを押下
            LicenseAgreementPage licenseAgreementPage = settingsPage.OpenLicenseAgreementPage();
            licenseAgreementPage.AssertLicenseAgreementPage();

            //app.Repl();
            var h1 = app.Query(c => c.Css("a"));
            //app.ScrollDown("https");
            app.ScrollDown(x => x.Marked("LicenseAgreementPageTitle").Class("WebView"));

            //Xamarin.UITest.Configuration.AndroidAppConfigurator.WaitTimes.WaitForTimeout (1000);
            //app.Tap(h1.Value);
            //Thread.Sleep(8000);
            //app.Back();
            ////app.Tap(c => c.Marked("PrivacyPolicyPageTitle").Class("ButtonRenderer").Index(0));
            ////app.Tap(h1.Value);

            //Console.WriteLine(h1.Html);

        }
        */

        [Test]
        [Category("en-US,Zh-Hans")]
        public void Case02_Test()
        {
            HomePage home = new HomePage();
            home.AssertHomePage();

            MenuPage menuPage = home.OpenMenuPage();
            menuPage.AssertMenuPage();

            //S1 ホーム画面で、ハンバーガーメニュー内の「使い方」ボタンを押下
            HelpMenuPage helpMenuPage = menuPage.OpenHelpMenuPage();
            helpMenuPage.AssertHelpMenuPage();

            //S2 「使い方」画面で、「接触の記録を停止 / 情報を削除するには」ボタンを押下
            HelpPage4 helpPage4 = helpMenuPage.OpenHelpPage4();
            helpPage4.AssertHelpPage4();

            //端末言語取得
            var cultureText = AppManager.GetCurrentCultureBackDoor();

            //ライセンステキストの取得
            var license_test = app.Query(x => x.Id("toolbar").Class("AppCompatTextView").Index(0))[0];

            //言語から比較する単語をjsonから取得
            string ComparisonText = (string)AppManager.Comparison(cultureText, "HelpPage4Title");

            //比較
            //期待値 :「Reinitialize the app」画面へ遷移すること
            Assert.AreEqual(license_test.Text, ComparisonText);

        }
        

    }
    }