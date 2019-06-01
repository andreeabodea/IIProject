import { Component, Inject } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef, MatIconModule } from '@angular/material';

@Component({
  selector: 'app-message-box',
  templateUrl: './message-box.component.html',
  styleUrls: ['./message-box.component.css']
})
export class MessageBoxComponent {
  public message: string;
  public title: string;
  public isErrorDialog: boolean;
  constructor(public dialogRef: MatDialogRef<MessageBoxComponent>, @Inject(MAT_DIALOG_DATA) confData: any) {
    this.title = confData.title;
    this.message = confData.message;
    this.isErrorDialog = confData.isErrorDialog ? confData.isErrorDialog : false;
  }

  onNoClick(): void {
    this.dialogRef.close();
  }

}
