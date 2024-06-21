import { Component } from '@angular/core';
import { AutoService } from '../../auto.service';
import { iAuto } from '../../models/auto';

@Component({
  selector: 'app-home-page',
  templateUrl: './home-page.component.html',
  styleUrl: './home-page.component.scss',
})
export class HomePageComponent {
  autoArr: iAuto[] = [];
  brandArr: string[] = [];
  twoAutoRandom: iAuto[] = [];

  constructor(private autoSvc: AutoService) {}

  async ngOnInit() {
    this.autoArr = await this.autoSvc.getAuto();
    console.log(this.autoArr);
    this.twoAutoRandom = await this.autoSvc.getRandomAuto();
    console.log(this.twoAutoRandom);
    this.brandArr = await this.autoSvc.getBrandsAuto();
    console.log(this.brandArr);
  }
}
