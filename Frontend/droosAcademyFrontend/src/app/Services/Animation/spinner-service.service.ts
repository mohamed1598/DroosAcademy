import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class SpinnerService {

  // visibility: BehaviorSubject<boolean>;
  visibility: boolean;

  constructor() {
    // this.visibility = new BehaviorSubject(false);
  }

  show() {
    this.visibility=true;
  }

  hide() {
    this.visibility=false;
  }
}