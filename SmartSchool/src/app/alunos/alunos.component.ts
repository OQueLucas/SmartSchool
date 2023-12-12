import { Component, OnInit, TemplateRef, afterNextRender } from '@angular/core';
import { Aluno } from '../models/Aluno';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { AlunosService } from './aluno.service';

@Component({
  selector: 'app-alunos',
  templateUrl: './alunos.component.html',
  styleUrls: ['./alunos.component.css'],
})
export class AlunosComponent implements OnInit {
  public alunoForm: FormGroup;
  public titulo = 'Alunos';
  public alunoSelecionado!: Aluno;
  public modalRef!: BsModalRef;
  public alunos: Aluno[];

  openModal(template: TemplateRef<void>) {
    this.modalRef = this.modalService.show(template);
  }

  constructor(
    private fb: FormBuilder,
    private modalService: BsModalService,
    private alunoService: AlunosService
  ) {
    this.criarForm();
  }

  ngOnInit(): void {
    this.carregarAlunos();
  }

  carregarAlunos() {
    this.alunoService.getAll().subscribe({
      next: (alunos: Aluno[]) => {
        this.alunos = alunos;
      },
      error: (erro: any) => {
        console.error(erro);
      },
    });
  }

  criarForm() {
    this.alunoForm = this.fb.group({
      nome: ['', Validators.required],
      sobrenome: ['', Validators.required],
      telefone: ['', Validators.required],
    });
  }

  alunoSubmit() {
    console.log(this.alunoForm.value);
  }

  alunoSelect(aluno: Aluno) {
    this.alunoSelecionado = aluno;
    this.alunoForm.patchValue(aluno);
  }

  voltar() {
    this.alunoSelecionado = null;
  }
}
