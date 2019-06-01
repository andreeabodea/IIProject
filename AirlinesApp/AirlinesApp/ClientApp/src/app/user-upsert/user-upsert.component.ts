import { Component, OnInit, Inject } from '@angular/core';
import { User } from './user.class';
import { FormGroup, FormBuilder, FormControl, FormGroupDirective, NgForm, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { UsersService } from '../services/users.service';

export enum UpsertMode {
  create = 1,
  update = 2
}

@Component({
  selector: 'app-user-upsert',
  templateUrl: './user-upsert.component.html',
  styleUrls: ['./user-upsert.component.css']
})
export class UserUpsertComponent {

  private user: User;
  public dialogForm: FormGroup;
  public errors: string;
  public upsertMode: UpsertMode;

  constructor(public dialogRef: MatDialogRef<UserUpsertComponent>,
    @Inject(MAT_DIALOG_DATA) userData: any,
    private fb: FormBuilder,
    private usersService: UsersService) {
    this.user = userData.user;
    this.upsertMode = userData.upsertMode;
    let controlSet = {
      userId: [this.user.userId, [Validators.required]],
      isEnabled: [this.user.isEnabled],
      isAdmin: [this.user.isAdmin],
    };
    controlSet["user"] = this.user;
    this.dialogForm = this.fb.group(controlSet);
  }

  formInvalid() {
    return this.dialogForm.invalid;
  }

  onNoClick(): void {
    this.dialogRef.close();
  }

  public save() {
    if (this.upsertMode === UpsertMode.create) {
      this.createUser();
    } else if (this.upsertMode === UpsertMode.update) {
      this.updateUser();
    }
  }

  public cancel() {
    this.dialogRef.close();
  }

  private createUser() {
    let result = this.dialogForm.value;
    this.usersService.create(result.userId, result.isEnabled, result.isAdmin).subscribe(
      result => {
        this.errors = "";
        this.dialogRef.close("created");
      },
      errors => this.errors = errors
    );
  }

  private updateUser() {
    let result = this.dialogForm.value;
    this.usersService.update(result.user.id, result.userId, result.isEnabled, result.isAdmin).subscribe(
      result => {
        this.errors = "";
        this.dialogRef.close("updated");
      },
      errors => this.errors = errors
    );
  }
}
