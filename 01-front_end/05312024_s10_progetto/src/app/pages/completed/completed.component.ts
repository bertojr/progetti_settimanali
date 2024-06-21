import { Component } from '@angular/core';
import { TodoService } from '../../services/todo.service';
import { iTodo } from '../../models/itodo';

@Component({
  selector: 'app-completed',
  templateUrl: './completed.component.html',
  styleUrl: './completed.component.scss',
})
export class CompletedComponent {
  todosArrCompleted: iTodo[] = [];
  constructor(private todoSvc: TodoService) {}

  ngOnInit(): void {
    this.todosArrCompleted = this.todoSvc.getTodosCompleted();
  }
}
