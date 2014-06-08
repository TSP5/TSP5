#include <cstdio>
#include <cstring>
char *add(char *first, char *second, char *sum)
{
	char *a,*b,*c=sum,temp;
	*c=0;
	a=strrev(first);
	b=strrev(second);
	while(*a||*b)
	{
		temp=0;
		if(*a)
		{
			if(*b)
			{
				temp=(*c+(*a-'0')+(*b-'0'))/10;
				*c=(*c+(*a-'0')+(*b-'0'))%10+'0';
			}
			else
			{
				temp=(*a-'0'+temp)/10;
				*c=(*a-'0'+*c)%10+'0';
				*(b+1)=0;
			}

		}
		else
		{
			temp=(*b-'0'+*c)/10;
			*c=(*c+(*b-'0'))%10+'0';
			*(a+1)=0;
		}
		*(c+1)=temp;
		c++;
		a++;
		b++;
	}
	if(temp)
	{
		*c=temp+'0';
		c++;
		*c=0;
	}
	else
		*c=0;
	return strrev(sum);
}
int main(void)
{
	int i,x,T;
	char a[1100],b[1100],c[1100],*p,*p1,*p2;
	p=c;
	scanf("%d",&T);
	for(i=1;i<=T;i++)
	{
		getchar();
		scanf("%s%s",a,b);
		for(x=0;'0'==a[x];x++);
		if(0==a[x])
			p1=a+x-1;
		else
			p1=a+x;
		for(x=0;'0'==b[x];x++);
		if(0==b[x])
			p2=b+x-1;
		else
			p2=b+x;
		printf("Case %d:\n%s + %s = ",i,p1,p2);
		p=add(p1,p2,c);
		printf("%s\n",p);
		if(i!=T)
			printf("\n");
	}
	return 0;
}