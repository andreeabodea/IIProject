import { Injectable } from "@angular/core";
import { MatDialog, MatDialogRef } from "@angular/material";
import { Router } from "@angular/router";
import { MessageBoxComponent } from "../message-box/message-box.component";

@Injectable()
export class DialogService {

  private static readonly messageBoxWidth: string = '70%';
  private static readonly messageBoxMaxWidth: string = '600px';
  public dialogRef: MatDialogRef<MessageBoxComponent>;
  constructor(public dialog: MatDialog,
    public router: Router) {
  }

  public showMessageBox(title: string, message: string) {
    this.dialogRef = this.dialog.open(MessageBoxComponent, {
      width: DialogService.messageBoxWidth,
      maxWidth: DialogService.messageBoxMaxWidth,
      data: { title: title, message: message, isErrorDialog: false },
      disableClose: true
    });

    return this.dialogRef;
  }

  public showErrorMessageBox(message: string) {
    if (!this.dialog.openDialogs || !this.dialog.openDialogs.length) {
      this.dialogRef = this.dialog.open(MessageBoxComponent, {
        width: DialogService.messageBoxWidth,
        maxWidth: DialogService.messageBoxMaxWidth,
        data: { title: "Error", message: message, isErrorDialog: true },
        disableClose: true

      });
    }

  }

  public closeDialog() {
    this.dialogRef.close();
  }
}
