export class User {
  public userId: string;
  public isEnabled: boolean;
  public isAdmin: boolean;
  public id: string;

  constructor(idParam: string, userIdParam: string) {
    this.userId = userIdParam;
    this.isEnabled = false;
    this.isAdmin = false;
    this.id = idParam;
  }
}
