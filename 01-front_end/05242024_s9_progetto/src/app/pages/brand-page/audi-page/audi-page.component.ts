import { Component } from '@angular/core';
import { AutoService } from '../../../auto.service';
import { iAuto } from '../../../models/auto';

@Component({
  selector: 'app-audi-page',
  templateUrl: './audi-page.component.html',
  styleUrl: '../brand-page.component.scss',
})
export class AudiPageComponent {
  autoAudi: iAuto[] = [];
  constructor(private AutoSvc: AutoService) {}
  async ngOnInit() {
    this.autoAudi = await this.AutoSvc.getAutoByBrand('Audi');
    console.log(this.autoAudi);
  }
}
