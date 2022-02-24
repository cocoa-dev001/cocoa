﻿using System;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;

// Aliases Func<AppQuery, AppQuery> with Query
using Query = System.Func<Xamarin.UITest.Queries.AppQuery, Xamarin.UITest.Queries.AppQuery>;


namespace CovidRadar.UITestV2
{
    public class HelpPage1 : BasePage
    {
        /***********
         * どのようにして接触を記録していますか？
        ***********/

        readonly Query toolBarBack;


        protected override PlatformQuery Trait => new PlatformQuery
        {
            Android = x => x.Marked("HelpPage1Title"),
            iOS = x => x.Marked("HelpPage1Title")
        };

        public HelpPage1()
        {
            toolBarBack = x => x.Marked("MasterDetailPageTitle").Class("AppCompatImageButton").Index(0); //戻るボタン



            if (OnAndroid)
            {
            }

            if (OniOS)
            {

            }
        }

        // メニュー表示確認
        public void AssertHelpPage1(TimeSpan? timeout = default(TimeSpan?))
        {
            base.AssertOnPage(timeout);
            app.Screenshot(this.GetType().Name.ToString());
        }
        public void ToolBarBack()
        {
            app.Tap(toolBarBack);
        }







    }
}