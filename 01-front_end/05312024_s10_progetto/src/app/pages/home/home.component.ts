import { TodoService } from '../../services/todo.service';
import { Component } from '@angular/core';
import { UserService } from '../../services/user.service';
import { iTodo } from '../../models/itodo';
import { iUser } from '../../models/iuser';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrl: './home.component.scss',
})
export class HomeComponent {
  todosArr: iTodo[] = [];
  usersArr: iUser[] = [];
  constructor(private todoSvc: TodoService, private userSvc: UserService) {}

  ngOnInit() {
    this.todosArr = this.todoSvc.todosArr;
    console.log(this.todosArr);
    this.usersArr = this.userSvc.usersArr;
    console.log(this.usersArr);
  }
}
