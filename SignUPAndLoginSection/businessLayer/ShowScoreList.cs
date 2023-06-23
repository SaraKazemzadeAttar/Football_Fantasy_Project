using SignUPAndLoginSection.businessLayer;
using SignUPAndLoginSection.presentationLayer;
using SignUPAndLoginSection.DataAccessLayer;

namespace SignUPAndLoginSection.businessLayer;

public static class ShowScoreList
{
    public static List<string> makeListOfUserNames()
    {
        return UsersData.createListOfUsernames();
    }
    
    
    
    


}