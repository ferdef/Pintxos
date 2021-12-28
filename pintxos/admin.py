from django.contrib import admin
from .models import Pintxo, PintxoVote

# Register your models here.
admin.site.register(Pintxo)
admin.site.register(PintxoVote)