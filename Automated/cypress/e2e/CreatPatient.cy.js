import { FormFiller } from "./pages/FormFiller"
import { LoginPage } from "./pages/loginpage"

const formfiller = new FormFiller()
const loginPage = new LoginPage()

describe('Creating Patient Test Case', () => {

    beforeEach (()=>{
        cy.visit('http://localhost:5044/Home/Login')
    })

    it('Creating Patient', () => {
        loginPage.enterUsername('demo')
        loginPage.enterPassword('demo')
        loginPage.ClickLoginButton()
        cy.contains('Patients').click()
    
        cy.contains('Create New').click()
        
        formfiller.enterGivenName('Prince')
        formfiller.enterFamilyName('Okumo')
        formfiller.enterFurtherGivenNames('Jr')
        //formfiller.enterAddress('leppavara')
        formfiller.ClickCreateButton()
        
        })

    it('Back to list Test', () => {
    loginPage.enterUsername('demo')
    loginPage.enterPassword('demo')
    loginPage.ClickLoginButton()
    cy.contains('Patients').click()

    cy.contains('Create New').click()

    cy.get(':nth-child(5) > a').click()
    })

    

  })