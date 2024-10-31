
import { LoginPage } from "./pages/loginpage"
const loginPage = new LoginPage()

describe('All login test list', () => {

    beforeEach (()=>{
        cy.visit('http://localhost:5044/Home/Login')
    })

    it('Login test with valid Credentials', () => {
        loginPage.enterUsername('demo')
        loginPage.enterPassword('demo')
        loginPage.ClickLoginButton()
        
    })

    it('Login test with invalid Credentials', () => {
        loginPage.enterUsername('demo')
        loginPage.enterPassword('demothet')
        loginPage.ClickLoginButton()
        cy.contains('Incorrect username or password.')
    
    })

    it('Login test with No Credentials', () => {
    
        loginPage.ClickLoginButton()
        cy.contains('You must provide a username and a password.')
    
    })
  })