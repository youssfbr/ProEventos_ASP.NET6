import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';

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

  constructor(private router: Router) { }

  ngOnInit(): void {
  }

  listar(): void {
    this.router.navigate([`/${this.title?.toLocaleLowerCase()}/lista`])
  }

}
