import { Component, OnInit, Input } from '@angular/core';
import { NutritionalValue } from '../../common/nutritional-value';

@Component({
  selector: 'app-indicators',
  templateUrl: './indicators.component.html',
  styleUrls: ['./indicators.component.css']
})
export class IndicatorsComponent implements OnInit {

  @Input() indicators: NutritionalValue;
  constructor() { }

  ngOnInit() {
  }

}
