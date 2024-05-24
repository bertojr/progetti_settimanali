import { Component } from '@angular/core';
import { iAuto } from '../../models/auto';
import { AutoService } from '../../auto.service';

@Component({
  selector: 'app-ford-page',
  templateUrl: './ford-page.component.html',
  styleUrl: './ford-page.component.scss',
})
export class FordPageComponent {
  autoArr: iAuto[] = [];

  constructor(private autoSvc: AutoService) {}

  ngOnInit() {}
}
