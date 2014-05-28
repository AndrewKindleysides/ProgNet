type Contact = {
	FirstName: string
	MiddleInitial: string
	LastName: string
	EmailAddress: string
	IsEmailVerified: bool

	Address1: string
	Address2: string option
	City: string
	County: string
	PostCode: string
	IsAddressVerified: bool
}