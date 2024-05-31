import { Component } from '@angular/core';
import { TodoService } from '../../services/todo.service';
import { iTodo } from '../../models/itodo';
import { iUser } from '../../models/iuser';

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  styleUrl: './users.component.scss',
})
export class UsersComponent {
  usersWithTodos: { user: iUser; todos: iTodo[] }[] = [];
  constructor(private todoSvc: TodoService) {}

  ngOnInit() {
    this.usersWithTodos = this.getUserWithTodos();
    console.log(this.usersWithTodos);
  }

  getUserWithTodos(): { user: iUser; todos: iTodo[] }[] {
    return this.todoSvc.getUsersWithTodos();
  }
}
