from django.contrib import admin
from .models import Pintxo, PintxoVote

@admin.register(Pintxo)
class PintxoAdmin(admin.ModelAdmin):
    list_display = ('name', 'creator', 'contest')
    list_filter = ('contest', 'creator')

@admin.register(PintxoVote)
class PintxoVoteAdmin(admin.ModelAdmin):
    list_display = ('pintxo', 'voter', 'value')
    list_filter = ('pintxo', 'voter', 'pintxo__contest')
