export class User {
    Email: string;
    Password: string;
    ConfirmPassword: string;
    FirstName: string;
    LastName: string;
    DayOfBirth: string;
    Address: string;

    constructor(user: User) {
        this.Address = user.Address;
        this.Email = user.Email;
        this.FirstName = user.FirstName;
        this.LastName = user.LastName;
        this.Password = user.Password;
        this.ConfirmPassword = user.ConfirmPassword;
        this.DayOfBirth = user.DayOfBirth;
    }
}
