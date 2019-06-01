import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-users-add-user',
  template: '  <div class="addButton">' +
    '         <button mat-button mat-icon-button type="button" aria-label="Toggle sidenav" (click)="click()"> ' +
    '               <mat-icon aria-label="Add">add</mat-icon>' +
    '        </button>' +
    '        </div>',
  styleUrls: ['./users-list.component.css']
})

export class AddUserComponent implements OnInit {
  @Input() click: Function;

  ngOnInit() {
  }
}
