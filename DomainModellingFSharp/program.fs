module Blah

module EmailContactInfo = 
    open System

    type EmailAddress = string
    type UnverifiedData = EmailAddress
    type VerifiedData = EmailAddress * DateTime
    type T = 
        | UnverifiedState of UnverifiedData
        | VerifiedState of VerifiedData

    let create email = 
        UnverifiedState email

    let verified emailContactInfo dateVerified =
        match emailContactInfo with 
        | UnverifiedState email ->
            VerifiedState(email,dateVerified)
        | VerifiedState _ ->
            emailContactInfo

    let sendVerifactionEmail emailContactInfo = 
        match emailContactInfo with 
        | UnverifiedState email ->
            //send email
            printfn "Sending Email"
        | VerifiedState _ ->
            //do nothing
            printfn "Not sending an email -- address already verified"

type PersonalName = {
    FirstName: string
    MiddleInitial: string option
    LastName: string
}

type Address = {
    Address1: string
    Address2: string
    City: string
    County: string
    PostCode: string
}

type AddressInfo = {
    Address: Address
    //true if validated against address service
    IsAddressVerified: bool 
}

type Contact = {
    PersonalName: PersonalName
    EmailContactInfo: EmailContactInfo.T
    AddressInfo: AddressInfo
}

let personalName = { FirstName = "Ian"; MiddleInitial = Some "J"; LastName = "Russell" }
let emailContactInfo =  EmailContactInfo.create "hello@add.com"
let address = { Address1 = "road"; Address2 = "street";City = "London"; County="east"; PostCode = "m22 222" }
let addressInfo = { Address= address; IsAddressVerified = false }
let contact = { PersonalName= personalName; EmailContactInfo= emailContactInfo; AddressInfo= addressInfo }

printfn "%s" contact.PersonalName.LastName
let foo  = EmailContactInfo.verified emailContactInfo System.DateTime.Now
EmailContactInfo.sendVerifactionEmail emailContactInfo
EmailContactInfo.sendVerifactionEmail foo