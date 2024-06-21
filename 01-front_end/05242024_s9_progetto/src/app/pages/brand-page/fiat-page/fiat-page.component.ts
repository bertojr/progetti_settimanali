import { iAuto } from '../../../models/auto';
import { AutoService } from './../../../auto.service';
import { Component } from '@angular/core';

@Component({
  selector: 'app-fiat-page',
  templateUrl: './fiat-page.component.html',
  styleUrl: '../brand-page.component.scss',
})
export class FiatPageComponent {
  autoFiat: iAuto[] = [];
  constructor(private AutoSvc: AutoService) {}
  async ngOnInit() {
    this.autoFiat = await this.AutoSvc.getAutoByBrand('Fiat');
    console.log(this.autoFiat);
  }
}
