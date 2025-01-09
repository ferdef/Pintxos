from django.contrib import admin
from .models import Profile, Family

class ProfileInline(admin.TabularInline):
    model = Profile

@admin.register(Family)
class FamilyAdmin(admin.ModelAdmin):
    inlines = [ProfileInline]

@admin.register(Profile)
class ProfileAdmin(admin.ModelAdmin):
    pass

