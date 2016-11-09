﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:2.1.0.0
//      SpecFlow Generator Version:2.0.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace SeedingATree
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.1.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute()]
    public partial class AnOrgStructureCanBeExpressedInGherkinFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "An org structure can be expressed in gherkin.feature"
#line hidden
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassInitializeAttribute()]
        public static void FeatureSetup(Microsoft.VisualStudio.TestTools.UnitTesting.TestContext testContext)
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner(null, 0);
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "An org structure can be expressed in gherkin", null, ProgrammingLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassCleanupAttribute()]
        public static void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestInitializeAttribute()]
        public virtual void TestInitialize()
        {
            if (((testRunner.FeatureContext != null) 
                        && (testRunner.FeatureContext.FeatureInfo.Title != "An org structure can be expressed in gherkin")))
            {
                SeedingATree.AnOrgStructureCanBeExpressedInGherkinFeature.FeatureSetup(null);
            }
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCleanupAttribute()]
        public virtual void ScenarioTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioSetup(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioStart(scenarioInfo);
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Seed an org tree using a table with a row for each org and parent relation")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "An org structure can be expressed in gherkin")]
        public virtual void SeedAnOrgTreeUsingATableWithARowForEachOrgAndParentRelation()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Seed an org tree using a table with a row for each org and parent relation", ((string[])(null)));
#line 3
this.ScenarioSetup(scenarioInfo);
#line hidden
            TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                        "Name",
                        "Parent"});
            table1.AddRow(new string[] {
                        "Board",
                        ""});
            table1.AddRow(new string[] {
                        "HOFin",
                        "Board"});
            table1.AddRow(new string[] {
                        "HOTech",
                        "Board"});
            table1.AddRow(new string[] {
                        "ITInfra",
                        "HOTech"});
            table1.AddRow(new string[] {
                        "SWDevSvc",
                        "HOTech"});
            table1.AddRow(new string[] {
                        "SWPmo",
                        "SWDevSvc"});
            table1.AddRow(new string[] {
                        "SWEng",
                        "SWDevSvc"});
#line 4
 testRunner.Given("I have the following organizations", ((string)(null)), table1, "Given ");
#line 14
 testRunner.When("I execute the specs", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 17
 testRunner.Then("I get the correct organizations.", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Seed an org tree using a table with a row for each org and column skipping")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "An org structure can be expressed in gherkin")]
        public virtual void SeedAnOrgTreeUsingATableWithARowForEachOrgAndColumnSkipping()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Seed an org tree using a table with a row for each org and column skipping", ((string[])(null)));
#line 20
this.ScenarioSetup(scenarioInfo);
#line hidden
            TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                        "Level1",
                        "Level2",
                        "Level3",
                        "Level4"});
            table2.AddRow(new string[] {
                        "Board",
                        "",
                        "",
                        ""});
            table2.AddRow(new string[] {
                        "",
                        "HOFin",
                        "",
                        ""});
            table2.AddRow(new string[] {
                        "",
                        "HOTech",
                        "",
                        ""});
            table2.AddRow(new string[] {
                        "",
                        "",
                        "ITInfra",
                        ""});
            table2.AddRow(new string[] {
                        "",
                        "",
                        "SWDevSvc",
                        ""});
            table2.AddRow(new string[] {
                        "",
                        "",
                        "",
                        "SWPmo"});
            table2.AddRow(new string[] {
                        "",
                        "",
                        "",
                        "SWEng"});
#line 21
 testRunner.Given("I have the following levelled org structure", ((string)(null)), table2, "Given ");
#line 31
 testRunner.When("I execute the specs", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 34
 testRunner.Then("I get the correct organizations.", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Seed an org tree using a table with a row for each org and indendation")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "An org structure can be expressed in gherkin")]
        public virtual void SeedAnOrgTreeUsingATableWithARowForEachOrgAndIndendation()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Seed an org tree using a table with a row for each org and indendation", ((string[])(null)));
#line 37
this.ScenarioSetup(scenarioInfo);
#line hidden
            TechTalk.SpecFlow.Table table3 = new TechTalk.SpecFlow.Table(new string[] {
                        "Org at level"});
            table3.AddRow(new string[] {
                        "Board"});
            table3.AddRow(new string[] {
                        ". HOFin"});
            table3.AddRow(new string[] {
                        ". HOTech"});
            table3.AddRow(new string[] {
                        ". . ITInfra"});
            table3.AddRow(new string[] {
                        ". . SWDevSvc"});
            table3.AddRow(new string[] {
                        ". . . SWPmo"});
            table3.AddRow(new string[] {
                        ". . . SWEng"});
#line 38
 testRunner.Given("I have the following intended org structure", ((string)(null)), table3, "Given ");
#line 48
 testRunner.When("I execute the specs", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 51
 testRunner.Then("I get the correct organizations.", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Seed an org tree using a multiline text with a row for each org and indendation w" +
            "ith dots")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "An org structure can be expressed in gherkin")]
        public virtual void SeedAnOrgTreeUsingAMultilineTextWithARowForEachOrgAndIndendationWithDots()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Seed an org tree using a multiline text with a row for each org and indendation w" +
                    "ith dots", ((string[])(null)));
#line 54
this.ScenarioSetup(scenarioInfo);
#line hidden
#line 55
 testRunner.Given("I have the following intended org structure as text", "Board       \r\n. HOFin     \r\n. HOTech    \r\n. . ITInfra \r\n. . SWDevSvc\r\n. . . SWPmo" +
                    " \r\n. . . SWEng ", ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 66
 testRunner.When("I execute the specs", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 69
 testRunner.Then("I get the correct organizations.", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Seed an org tree using a multiline text with a row for each org and indendation")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "An org structure can be expressed in gherkin")]
        public virtual void SeedAnOrgTreeUsingAMultilineTextWithARowForEachOrgAndIndendation()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Seed an org tree using a multiline text with a row for each org and indendation", ((string[])(null)));
#line 72
this.ScenarioSetup(scenarioInfo);
#line hidden
#line 73
 testRunner.Given("I have the following intended org structure as text", "Board       \r\n  HOFin     \r\n  HOTech    \r\n    ITInfra \r\n    SWDevSvc\r\n      SWPmo" +
                    " \r\n      SWEng ", ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 84
 testRunner.When("I execute the specs", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 87
 testRunner.Then("I get the correct organizations.", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
