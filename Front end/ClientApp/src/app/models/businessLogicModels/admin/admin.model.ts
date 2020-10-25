export class Admin {
    public id: number;
    public name: string;
    public email: string;
    public password: string

    public Admin(id: number, name: string, email: string, password: string){
        this.email = email;
        this.id = id;
        this.name = name;
        this.password = password;
    }
}

