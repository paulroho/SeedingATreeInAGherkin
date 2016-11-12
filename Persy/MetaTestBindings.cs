using TechTalk.SpecFlow;

namespace Persy

{
    [Binding]
    public class MetaTestBindings
    {
        [When(@"I execute the SpecFlow-specs")]
        public void WennIchDieSpecFlow_TestsAusfuhre()
        {
            //ScenarioContext.Current.Pending();
        }

        [Then(@"the following objects of hard entities are available:")]
        public void DannGibtEsFolgendeObjekteHarterEntitatenInDerBESY_Datenbank(Table table)
        {
            
        }

        [Then(@"the AD-group '(.*)' is assigned to the position '(.*)'")]
        public void DannDieAD_GruppeIstDerPositionZugeordnet(string adGruppenName, string positionsName)
        {
            
        }

        [Then(@"the following objects of weak entities are available:")]
        public void DannEsGibtFolgendeObjekteWeicherEntitatenInDerBESY_Datenbank(Table table)
        {
            
        }

        [Then(@"in the AD there is an AD-user '([\w\\\\]*)' and the AD-group '([\w\.]*)'\.")]
        public void DannImADGibtEsDenAD_UserAd_Gruppe_(string adUserName, string adGroupName)
        { }
    }
}