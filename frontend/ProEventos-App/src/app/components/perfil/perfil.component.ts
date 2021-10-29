import { ValidatorField } from './../../helpers/ValidatorField';
import { FormGroup, FormBuilder, AbstractControlOptions, Validators } from '@angular/forms';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-perfil',
  templateUrl: './perfil.component.html',
  styleUrls: ['./perfil.component.scss']
})
export class PerfilComponent implements OnInit {

  form: FormGroup;
  //id!: string;
  loading = false;
  //submitted = false;

  constructor(private fb: FormBuilder) { }

  ngOnInit(): void {
    this.validation();
  }

  validation(): void {

    const formOptions: AbstractControlOptions = {
      validators: ValidatorField.MustMatch('senha', 'confirmarSenha')
    };

    this.form = this.fb.group({
      opcaoTitulo: ['', [Validators.required]],
      primeiroNome: ['', [Validators.required]],
      ultimoNome: ['', [Validators.required]],
      email: ['', [Validators.required, Validators.email]],
      telefone: ['', [Validators.required]],
      funcao: ['', [Validators.required]],
      descricao: ['', [Validators.required]],
      senha: ['', [Validators.required, Validators.minLength(6)]],
      confirmarSenha: ['', [Validators.required, Validators.minLength(6)]],
    }, formOptions);
  }

  // Pega um formField apenas com a letra F
  get f(): any { return this.form.controls; }

  onSubmit(): void {
    //this.submitted = true;

    // Vai parar aqui se o form estiver inválido
    if (this.form.invalid) {
      return;
    }

    this.loading = true;
  }

  resetForm(event: any): void {
    event.preventDefault();
    //this.submitted = false;
    this.form.reset();
  }

}
