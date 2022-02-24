﻿using System;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;

// Aliases Func<AppQuery, AppQuery> with Query
using Query = System.Func<Xamarin.UITest.Queries.AppQuery, Xamarin.UITest.Queries.AppQuery>;


namespace CovidRadar.UITestV2
{
    public class SettingsPage : BasePage
    {
        /***********
         * 設定ページ
        ***********/

        readonly Query openLicenseAgreementPage;
        readonly Query toolBarBack;
        readonly Query openMenuPage;
        readonly Query syokika;


        protected override PlatformQuery Trait => new PlatformQuery
        {
            Android = x => x.Marked("SettingsPageTitle"),
            iOS = x => x.Marked("SettingsPageTitle")
        };

        public SettingsPage()
        {
            openLicenseAgreementPage = x => x.Marked("MasterDetailPageTitle").Class("ButtonRenderer").Index(0); //ライセンスページ
            toolBarBack = x => x.Marked("MasterDetailPageTitle").Class("AppCompatImageButton").Index(0); //戻るボタン
            openMenuPage = x => x.Class("AppCompatImageButton").Marked("OK"); //ハンバーガーメニュー

            syokika = x => x.Marked("MasterDetailPageTitle").Class("ButtonRenderer").Index(1); //アプリ初期化

            if (OnAndroid)
            {
            }

            if (OniOS)
            {

            }
        }

        // メニュー表示確認
        public void AssertSettingsPage(TimeSpan? timeout = default(TimeSpan?))
        {
            base.AssertOnPage(timeout);
            app.Screenshot(this.GetType().Name.ToString());
        }

        public LicenseAgreementPage OpenLicenseAgreementPage()
        {
            app.Tap(openLicenseAgreementPage);
            return new LicenseAgreementPage();
        }

        public void ToolBarBack()
        {
            app.Tap(toolBarBack);
        }
        public void Syokika()
        {
            app.Tap(syokika);
            app.Tap(x => x.Id("button1"));
            app.Tap(x => x.Id("button1"));

        }

        public MenuPage OpenMenuPage()
        {
            app.Tap(openMenuPage);
            return new MenuPage();

        }




    }
}