import { Component, Input, input } from '@angular/core';
import { iTodo } from '../../models/itodo';
import { TodoService } from '../../services/todo.service';

@Component({
  selector: 'app-single-item',
  templateUrl: './single-item.component.html',
  styleUrl: './single-item.component.scss',
})
export class SingleItemComponent {
  @Input() todoItem!: iTodo;
  constructor(private todoSvc: TodoService) {}

  getUserName(userId: number) {
    return this.todoSvc.getUserName(userId);
  }
}
