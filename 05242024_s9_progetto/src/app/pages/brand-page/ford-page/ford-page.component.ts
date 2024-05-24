import { Component } from '@angular/core';
import { AutoService } from '../../../auto.service';
import { iAuto } from '../../../models/auto';

@Component({
  selector: 'app-ford-page',
  templateUrl: './ford-page.component.html',
  styleUrl: './ford-page.component.scss',
})
export class FordPageComponent {
  autoFord: iAuto[] = [];
  constructor(private AutoSvc: AutoService) {}
  async ngOnInit() {
    this.autoFord = await this.AutoSvc.getAutoByBrand('Ford');
    console.log(this.autoFord);
  }
}
