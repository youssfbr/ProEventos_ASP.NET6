import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-title',
  templateUrl: './title.component.html',
  styleUrls: ['./title.component.scss']
})
export class TitleComponent implements OnInit {

  @Input() iconClass = "fa fa-user";
  @Input() title?: string;
  @Input() subtitle?: string = "Desde 2021";
  @Input() buttonList = false;

  constructor() { }

  ngOnInit() {
  }

}
