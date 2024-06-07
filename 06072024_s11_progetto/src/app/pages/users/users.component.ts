import { Component } from '@angular/core';
import { UserService } from '../../services/user.service';
import { iUser } from '../../models/user';

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  styleUrl: './users.component.scss',
})
export class UsersComponent {
  usersArr: iUser[] = [];
  constructor(private userSvc: UserService) {}

  ngOnInit() {
    this.userSvc.getUsers().subscribe((users) => (this.usersArr = users));
  }
}
