from django.http import HttpResponse
from django.template import loader
from django.shortcuts import render

from .models import Contest, Pintxo, Vote

def index(request):
    return HttpResponse("Hello Contests")

def pintxos(request):
    pintxos_list = Pintxo.objects.all()
    template = loader.get_template("pintxo/index.html")
    context = {
        "pintxos_list": pintxos_list,
    }
    return HttpResponse(template.render(context, request))

def contest_detail(request, contest_id):
    return HttpResponse(f"Looking for contest {contest_id}")

def pintxo_detail(request, pintxo_id):
    return HttpResponse(f"Looking for pintxo {pintxo_id}")
