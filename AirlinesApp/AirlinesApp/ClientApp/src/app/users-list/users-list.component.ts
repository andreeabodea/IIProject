import { Component, OnInit, Output, ViewChild } from '@angular/core';
import { MatDialog, MatDialogRef, MatSort, MatTableDataSource } from '@angular/material';

import { UpsertMode, UserUpsertComponent } from '../user-upsert/user-upsert.component';
import { DialogService } from '../services/dialog.service';
import { UsersService } from '../services/users.service';
import { User } from '../user-upsert/user.class';

@Component({
  selector: 'app-users-list',
  templateUrl: './users-list.component.html',
  styleUrls: ['./users-list.component.css']
})
export class UsersListComponent implements OnInit {

  @Output() errors: string;
  usersDataSource: MatTableDataSource<User>;
  userList: User[];
  columnsToDisplay = ['userId', 'activated', 'admin', 'edit', 'delete'];
  @ViewChild(MatSort) sort: MatSort;
  public upsertMode: UpsertMode;

  constructor(private usersService: UsersService,
    public dialog: MatDialog,
    public dialogService: DialogService) {
    this.createNew = this.createNew.bind(this);
  }

  ngOnInit() {
  }

  ngAfterViewInit() {
    this.loadUsers();
  }

  private loadUsers() {
    this.usersService.getAllUsers().subscribe((usersResult: User[]) => {
      this.userList = usersResult;
      this.usersDataSource = new MatTableDataSource<User>(this.userList);
      this.usersDataSource.sort = this.sort;
    },
      e => {
        this.dialogService.showErrorMessageBox(e);
      });
  }

  private dialogRef: MatDialogRef<UserUpsertComponent, any>;

  createNew() {
    this.openUpsertDialog(UpsertMode.create);
  }

  update(user: User) {
    this.openUpsertDialog(UpsertMode.update, user);
  }

  private openUpsertDialog(upsertMode: UpsertMode, user: User = null) {
    let upsertedUser = user === undefined || user === null
      ? new User("", "") : user;

    this.dialogRef = this.dialog.open(UserUpsertComponent, {
      width: '80%',
      maxWidth: '1000px',
      data: {
        user: upsertedUser,
        upsertMode: upsertMode
      },
      disableClose: true
    });

    this.dialogRef.afterClosed().subscribe(result => {

      let message = '';
      if (result === 'created') {
        message = 'User successfully created.';
      } else if (result === 'updated') {
        message = 'User updated successfully.';
      } else {
        return;
      }
      this.reloadAfterSuccessfulOperation(message);
    });
  }

  private reloadAfterSuccessfulOperation(message: string) {
    this.loadUsers();
    this.dialogService.showMessageBox("Success", message);
  }

  delete(id: string) {
    this.usersService.delete(id).subscribe(result => {
      this.reloadAfterSuccessfulOperation('The user has been successfully deleted.');
    },
      errors => {
        this.dialogService.showErrorMessageBox(errors);
      });
  };
}
