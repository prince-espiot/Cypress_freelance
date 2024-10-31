import { FormFiller } from "./pages/FormFiller"
import { LoginPage } from "./pages/loginpage"

const formfiller = new FormFiller()
const loginPage = new LoginPage()

describe('Editing Patient Test Case', () => {

    beforeEach (()=>{
        cy.visit('http://localhost:5044/Home/Login')
    })

    it('Edit Patient', () => {
        loginPage.enterUsername('demo')
        loginPage.enterPassword('demo')
        loginPage.ClickLoginButton()
        cy.contains('Patients').click()
    
        cy.get(':nth-child(2) > :nth-child(6) > a').click()
        
        cy.contains('GivenName').should('have.text', 'GivenName')
        cy.contains('FamilyName').should('have.text', 'FamilyName')


       // cy.get(':nth-child(4) > .control-label').should('have.text', 'FurtherGivenNames')


        cy.contains('DateOfBirth').should('have.text', 'DateOfBirth')
        cy.contains('AdministrativeGender').should('have.text', 'AdministrativeGender')
       // cy.contains('Address').should('have.text', 'Address')
        
        })

    it('Back to list Test', () => {
    loginPage.enterUsername('demo')
    loginPage.enterPassword('demo')
    loginPage.ClickLoginButton()
    cy.contains('Patients').click()
    cy.get(':nth-child(2) > :nth-child(6) > a').click()
    cy.contains('Back to List').click()
    })

    

  })