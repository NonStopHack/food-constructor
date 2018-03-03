import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { FoodConstructorComponent } from './food-constructor.component';

describe('FoodConstructorComponent', () => {
  let component: FoodConstructorComponent;
  let fixture: ComponentFixture<FoodConstructorComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ FoodConstructorComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(FoodConstructorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
