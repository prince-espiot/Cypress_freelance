export class LoginPage {

    username_locator = '#Username'
    password_word = '#Password'
    login_locator = ':nth-child(3) > button'

    enterUsername(username){
        cy.get(this.username_locator).type(username)
            }
    enterPassword(password){
        cy.get(this.password_word).type(password)
    }

    ClickLoginButton(){
        cy.get(this.login_locator).click()
    }
}