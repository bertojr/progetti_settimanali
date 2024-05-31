import { Component, Input, input } from '@angular/core';
import { TodoService } from '../../services/todo.service';
import { iTodo } from '../../models/itodo';

@Component({
  selector: 'app-single-item',
  templateUrl: './single-item.component.html',
  styleUrl: './single-item.component.scss',
})
export class SingleItemComponent {
  @Input() todoItem!: iTodo;
}
