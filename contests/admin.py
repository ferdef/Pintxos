from django.contrib import admin

from .models import Contest

@admin.register(Contest)
class ContestAdmin(admin.ModelAdmin):
    fields = ('contest_date', 'active')
    list_display = ('contest_date', 'active')