export class FormFiller {

    GivenName_locator = '#GivenName' 
    FamilyName_locator = '#FamilyName'
    FurtherGivenNames_locator = '#FurtherGivenNames' 
    Address_locator = '#Address'
    login_locator = '.btn'

    enterGivenName(GivenName){
        cy.get(this.GivenName_locator).type(GivenName)
            }
    enterFamilyName(FamilyName){
        cy.get(this.FamilyName_locator).type(FamilyName)
    }
    enterFurtherGivenNames(FurtherGivenNames){
        cy.get(this.FurtherGivenNames_locator).type(FurtherGivenNames)
            }
    enterAddress(Address){
        cy.get(this.Address_locator).type(Address)
    }
    ClickCreateButton(){
        cy.get(this.login_locator).click()
    }
}