using TechTalk.SpecFlow;

namespace Persy
{
    [Binding]
    public class PermissionChainBindings
    {
        [Given(@"there is a permission chain '(\w+) \((\w+\\\w+)\) --- (\w+) --- ((?!inaktiv)\w+) - ([\w\.]+)'\.?")]
        public void AngenommenEsExistiertDieBerechtigungskette_AllesAktiv(string nachname, string fullLogin, string gruppenName, string positionsName, string adGroupName)
        { }

        [Given(@"there is a permission chain '(\w+) \((\w+\\\w+)\) --- (\w+) \(INACTIVE\) --- ((?!inaktiv)\w+) - ([\w\.]+)'\.?")]
        public void AngenommenEsExistiertDieBerechtigungskette_G_INAKTIV_NEU(string nachname, string fullLogin, string gruppenName, string positionsName, string adGroupName)
        { }

        [Given(@"there is a permission chain '(\w+) \((\w+\\\w+)\) xxx (\w+) *--- ((?!inaktiv)\w+) - ([\w\.]+)'\.?")]
        public void AngenommenEsExistiertDieBerechtigungskette_B2G_INAKTIV_NEU(string nachname, string fullLogin, string gruppenName, string positionsName, string adGroupName)
        { }
        // ReSharper disable UnusedParameter.Global

        [Given(@"there is a permission chain '(\w+) \((\w+\\\w+)\) " +
               @"xxx (\w+) \(INACTIVE\) " +
               @"--- ((?!inaktiv)\w+) - ([\w\.]+)'\.?")]
        public void GivenThereIsAPermissionChain_U2G_G_INACTIVE(string lastname, string fullLogin, 
                                                                string groupName, 
                                                                string positionName, string adGroupName)
        {
            // ...
        }
        // ReSharper restore UnusedParameter.Global

    }
}