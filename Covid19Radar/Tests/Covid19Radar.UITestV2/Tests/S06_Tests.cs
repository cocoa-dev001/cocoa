﻿using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace CovidRadar.UITestV2
{
    [TestFixture(Platform.Android)]
    [TestFixture(Platform.iOS)]
    public class S06_Tests : BaseTestFixture
    {
        public S06_Tests(Platform platform)
            : base(platform)
        {
        }

        [OneTimeSetUp]
        public override void OneTimeSetUp()
        {
            AppManager.StartApp();

        }

        /* ENをONにするモーダルをタップする動作を実装できないため、CASE1~5は手動実行
        [Test]
        public void Case01_Test()
        {
            //S1 「このアプリでできること」画面で、「次へ」ボタンを押下
            TutorialPage1 tutorialPage1 = new TutorialPage1();
            tutorialPage1.AssertTutorialPage1();

            //S2 「プライバシーについて」画面で、「利用規約へ」ボタンを押下
            TutorialPage2 tutorialPage2 = tutorialPage1.OpenTutorialPage2();
            tutorialPage2.AssertTutorialPage2();

            //S3 「利用規約」画面で、「規約に同意して次へ」ボタンを押下
            TutorialPage3 tutorialPage3 = tutorialPage2.OpenTutorialPage3();
            tutorialPage3.AssertTutorialPage3();

            //S4 「プライバシーポリシー」画面で、「同意する」ボタンを押下
            PrivacyPolicyPage privacyPolicyPage = tutorialPage3.OpenPrivacyPolicyPage();
            privacyPolicyPage.AssertPrivacyPolicyPage();

            //S5 「接触検知をご利用いただくために」画面で、「有効にする」ボタンを押下
            TutorialPage4 tutorialPage4 = privacyPolicyPage.OpenTutorialPage4();
            tutorialPage4.AssertTutorialPage4();

            //S6 EN許可ポップアップで、EN許可を「OKにする」ボタンを押下
            TutorialPage6 tutorialPage6 = tutorialPage4.OpenTutorialPage6();
            tutorialPage6.AssertTutorialPage6();
        

            ////S7 初回ナビゲーション完了画面で、遷移先選択肢ボタンをパターンを参照して押下
            //HelpMenuPage helpMenuPage = tutorialPage6.OpenHelpMenuPage();
            //helpMenuPage.AssertHelpMenuPage();

            //HomePage homePage = new HomePage();
            //homePage.AssertHomePage();
            //app.Repl();
        }

        [Test]
        public void Case05_Test()
        {
            //S1 「このアプリでできること」画面で、「次へ」ボタンを押下
            TutorialPage1 tutorialPage1 = new TutorialPage1();
            tutorialPage1.AssertTutorialPage1();

            //S2 「プライバシーについて」画面で、「利用規約へ」ボタンを押下
            TutorialPage2 tutorialPage2 = tutorialPage1.OpenTutorialPage2();
            tutorialPage2.AssertTutorialPage2();

            //S3 「利用規約」画面で、「規約に同意して次へ」ボタンを押下
            TutorialPage3 tutorialPage3 = tutorialPage2.OpenTutorialPage3();
            tutorialPage3.AssertTutorialPage3();

            //S4 「プライバシーポリシー」画面で、「同意する」ボタンを押下
            PrivacyPolicyPage privacyPolicyPage = tutorialPage3.OpenPrivacyPolicyPage();
            privacyPolicyPage.AssertPrivacyPolicyPage();

            //S5 「接触検知をご利用いただくために」画面で、「有効にする」ボタンを押下
            TutorialPage4 tutorialPage4 = privacyPolicyPage.OpenTutorialPage4();
            tutorialPage4.AssertTutorialPage4();

            //S6 EN許可ポップアップで、EN許可を「OKにする」ボタンを押下
            TutorialPage6 tutorialPage6 = tutorialPage4.OpenTutorialPage6BluetoothOff();
            tutorialPage6.AssertTutorialPage6();

            tutorialPage6.OpenHomePage();

            HomePage homePage = new HomePage();
            homePage.AssertHomePage();

            app.Repl();
        }
        */



        [Test]
        public void Case06_Test()
        {   
            
            TutorialPage1 tutorialPage1 = new TutorialPage1();
            tutorialPage1.AssertTutorialPage1();

            //S1 「このアプリでできること」画面で、「次へ」ボタンを押下
            TutorialPage2 tutorialPage2 = tutorialPage1.OpenTutorialPage2();
            tutorialPage2.AssertTutorialPage2();

            //S2 「プライバシーについて」画面で、「利用規約へ」ボタンを押下
            TutorialPage3 tutorialPage3 = tutorialPage2.OpenTutorialPage3();
            tutorialPage3.AssertTutorialPage3();
            
            //S3 「利用規約」画面で、「規約に同意して次へ」ボタンを押下
            PrivacyPolicyPage privacyPolicyPage = tutorialPage3.OpenPrivacyPolicyPage();
            privacyPolicyPage.AssertPrivacyPolicyPage();
            
            //S4 「プライバシーポリシー」画面で、「同意する」ボタンを押下
            TutorialPage4 tutorialPage4 = privacyPolicyPage.OpenTutorialPage4();
            tutorialPage4.AssertTutorialPage4();

            //S5 「接触検知をご利用いただくために」画面で、「あとで設定する」ボタンを押下
            TutorialPage6 tutorialPage6 = tutorialPage4.OpenTutorialPage6BluetoothOff();
            tutorialPage6.AssertTutorialPage6();

            //S6 SKIP

            //S7 初回ナビゲーション完了画面で、遷移先選択肢ボタンをパターンを参照して押下
            //期待値 : 「使い方」画面に遷移すること
            tutorialPage6.OpenHomePage();

            HomePage homePage = new HomePage();
            homePage.AssertHomePage();

            MenuPage menuPage = homePage.OpenMenuPage();
            menuPage.AssertMenuPage();

            HelpMenuPage helpMenuPage = menuPage.OpenHelpMenuPage();
            helpMenuPage.AssertHelpMenuPage();

        }

        /*　機内モード変更動作を実装できないため除外
        [Test]
        public void Case07_Test()
        {   //前提：機内モードがONになっていること
            //エミュレータ上ではwifiをOFFにすることで再現可能

            //S1 「このアプリでできること」画面で、「次へ」ボタンを押下
            TutorialPage1 tutorialPage1 = new TutorialPage1();
            tutorialPage1.AssertTutorialPage1();

            //S2 「プライバシーについて」画面で、「利用規約へ」ボタンを押下
            TutorialPage2 tutorialPage2 = tutorialPage1.OpenTutorialPage2();
            tutorialPage2.AssertTutorialPage2();

            //S3 「利用規約」画面で、「規約に同意して次へ」ボタンを押下、通信エラーのダイアログのOKボタンを押下
            TutorialPage3 tutorialPage3 = tutorialPage2.OpenTutorialPage3();

            tutorialPage3.AssertTutorialPage3();
            tutorialPage3.TapOpenPrivacyPolicyPage();
        }
        */


    }
}